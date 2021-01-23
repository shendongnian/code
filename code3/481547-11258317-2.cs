    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    public class FileProcessing
    {
        static public void ConvertXmlFile(String theFile)
        {
            string theExportFile = theFile.Replace(".xml", ".txt");
            List<List<String>> theColumns = new List<List<string>>();
            List<String> theHeader = new List<string>();
            List<String> CurrentDepth = new List<string>();
            XmlDocument theXml = new XmlDocument();
            try
            {
                theXml.Load(theFile);
            }
            catch (Exception ex)
            {
                //handle as you seem fit. I use an error reporting system that is called here.
                return;
            }
            XmlElement theElement = theXml.DocumentElement;
            CurrentDepth.Add(theElement.ParentNode.Name);//Start at document level
            String ItemGroupTag = "";//this stores the element that groups all items(This element represents the complete line)
            String LastTagName = "";//detect if there is a listitem case(item with same tag appearing in a grouptag having different attribute values).
            int GroupItemDepth = 0;
            do
            {
                //null can occure on various errors. When it falls bellow the GroupItemDepth, the search is over
                if (theElement == null || CurrentDepth.Count <= GroupItemDepth) break;
                String CurrentTagName = theElement.ParentNode.Name + "." + theElement.Name;
                //only advance if this is not a listitem or the ItemGroupTag
                if (CurrentDepth[CurrentDepth.Count - 1] == CurrentTagName && LastTagName != CurrentTagName)
                {
                    LastTagName = CurrentTagName;
                    if (theElement.NextSibling != null)
                    {
                        theElement = (XmlElement)theElement.NextSibling;
                        CurrentDepth[CurrentDepth.Count - 1] = LastTagName;
                        continue;
                    }
                    
                    theElement = (XmlElement)theElement.ParentNode;
                    CurrentDepth.RemoveAt(CurrentDepth.Count - 1);//I stepped one level up
                    continue;
                }
                //only check the list until I get the group tag
                if (ItemGroupTag == "")
                {
                    XmlNodeList theList = theXml.GetElementsByTagName(theElement.Name);
                    if (theList.Count > 1)
                    {
                        ItemGroupTag = CurrentTagName;
                        GroupItemDepth = CurrentDepth.Count;
                    }
                    else
                    {
                        LastTagName = theElement.ParentNode.Name + "." + theElement.Name;
                        CurrentDepth.Add(LastTagName);//Stepped one level down
                        theElement = (XmlElement)theElement.FirstChild;
                        continue;
                    }
                }
                //At this point I am in the GroupItem's entries
                //Check if the "line" has changed
                if (CurrentTagName == LastTagName && CurrentTagName == ItemGroupTag)
                {
                    //It has changed. Make sure all columns have equal number of elements. If not, fill them with empty strings
                    int MaxCount = 0;
                    //First pass, find the number of items that should be in every column. Second pass, only one element apart in all occasions that
                    //the count is not equal. Take in account that a column may appear out of nowhere, as an attribute, and fill it up to date
                    for (int loop = 0; loop < theColumns.Count; loop++) if (theColumns[loop].Count > MaxCount) MaxCount = theColumns[loop].Count;
                    for (int loop = 0; loop < theColumns.Count; loop++)
                    {
                        //A problem will appear in cases that the second entry is a new attribute.
                        if (MaxCount > 2 && theColumns[loop].Count == 1)
                        {
                            while (theColumns[loop].Count != MaxCount) theColumns[loop].Insert(0, "");
                        }
                        else if (theColumns[loop].Count != MaxCount) theColumns[loop].Add("");
                    }
                    CurrentDepth.RemoveAt(CurrentDepth.Count - 1);//Remove the last entry of the group item
                }
                //Add a column for the tag, if there is none, or find its index, IF, this tag does not have child nodes
                int theColumnIndex = theHeader.IndexOf(CurrentTagName);
                if (theColumnIndex == -1 && !theElement.HasChildNodes)
                {
                    theHeader.Add(CurrentTagName);
                    theColumns.Add(new List<string>());
                    theColumnIndex = theHeader.Count - 1;
                }
                if (theElement.HasAttributes)
                {
                    XmlAttributeCollection theAttributes = theElement.Attributes;
                    for (int loop = 0; loop < theAttributes.Count; loop++)
                    {
                        theColumnIndex = theHeader.IndexOf(theElement.Name + "." + theAttributes[loop].Name);
                        if (theColumnIndex == -1)
                        {
                            theColumns.Add(new List<String>());
                            theHeader.Add(theElement.Name + "." + theAttributes[loop].Name);
                            theColumnIndex = theHeader.Count - 1;
                        }
                        if (theAttributes[loop].Value == null)
                        {
                            if (CurrentTagName == LastTagName && CurrentTagName != ItemGroupTag)
                                theColumns[theColumnIndex][theColumns[theColumnIndex].Count - 1] += "|";
                            else theColumns[theColumnIndex].Add("");
                        }
                        else
                        {
                            if (CurrentTagName == LastTagName && CurrentTagName != ItemGroupTag)
                                theColumns[theColumnIndex][theColumns[theColumnIndex].Count - 1] += "|" + theAttributes[loop].Value.ToString();
                            else theColumns[theColumnIndex].Add(theAttributes[loop].Value.ToString());
                        }
                    }
                }
                else if (!theElement.HasChildNodes)
                {
                    if (theElement.Value == null)
                    {
                        if (CurrentTagName == LastTagName && CurrentTagName != ItemGroupTag) theColumns[theColumnIndex][theColumns[theColumnIndex].Count - 1] += "|";
                        else theColumns[theColumnIndex].Add("");//empty string for a null value
                    }
                    else
                    {
                        if (CurrentTagName == LastTagName && CurrentTagName != ItemGroupTag) theColumns[theColumnIndex][theColumns[theColumnIndex].Count - 1] += "|" +
                            theElement.Value.ToString();
                        else theColumns[theColumnIndex].Add(theElement.Value.ToString());
                    }
                }
                LastTagName = CurrentTagName;
                if (theElement.HasChildNodes)
                {
                    theElement = (XmlElement)theElement.FirstChild;
                    CurrentDepth.Add(LastTagName);//Went down a level
                }
                else if (theElement.NextSibling != null)
                {
                    theElement = (XmlElement)theElement.NextSibling;
                    //Prevent overwriting a previous group level when a list item occurs
                    if (theElement.ParentNode.Name + "." + theElement.Name == LastTagName && CurrentDepth[CurrentDepth.Count - 1] != LastTagName)
                        CurrentDepth.Add(LastTagName);
                    else CurrentDepth[CurrentDepth.Count - 1] = LastTagName;
                }
                else
                {
                    theElement = (XmlElement)theElement.ParentNode;
                    CurrentDepth.RemoveAt(CurrentDepth.Count - 1);//Went up a Level
                }
            } while (theElement != theXml.DocumentElement);
            //Put Everything together and write them to a file
            List<String> theLines = new List<string>();
            String theLine = "";
            for (int loop = 0; loop < theHeader.Count; loop++) theLine += "\t" + theHeader[loop];
            if (theLine != "") theLines.Add(theLine.Substring(1));
            int aMaxCount = 0;
            //Do a last check for row count consistency in columns
            for (int loop = 0; loop < theColumns.Count; loop++) if (theColumns[loop].Count > aMaxCount) aMaxCount = theColumns[loop].Count;
            for (int loop = 0; loop < theColumns.Count; loop++)
            {
                if (aMaxCount > 2 && theColumns[loop].Count == 1)
                {
                    while (theColumns[loop].Count != aMaxCount) theColumns[loop].Insert(0, "");
                }
                else if (theColumns[loop].Count != aMaxCount) theColumns[loop].Add("");
            }
            for (int loop = 0; loop < theColumns[0].Count; loop++)
            {
                theLine = "";
                for (int loop1 = 0; loop1 < theColumns.Count; loop1++) theLine += "\t" + theColumns[loop1][loop].Replace('\t', ' ');
                if (theLine != "") theLines.Add(theLine.Substring(1));
            }
            File.WriteAllLines(theExportFile, theLines.ToArray(), Encoding.UTF8);
        }
    }
