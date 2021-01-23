        string JSONDeserialized {get; set;}
        public int indentLevel;
        private bool JSONDictionarytoYAML(Dictionary<string, object> dict)
        {
            bool bSuccess = false;
            indentLevel++;
            foreach (string strKey in dict.Keys)
            {
                string strOutput = "".PadLeft(indentLevel * 3) + strKey + ":";
                JSONDeserialized+="\r\n" + strOutput;
                object o = dict[strKey];
                if (o is Dictionary<string, object>)
                {
                    JSONDictionarytoYAML((Dictionary<string, object>)o);
                }
                else if (o is ArrayList)
                {
                    foreach (object oChild in ((ArrayList)o))
                    {
                        if (oChild is string)
                        {
                            strOutput = ((string)oChild);
                            JSONDeserialized += strOutput + ",";
                        }
                        else if (oChild is Dictionary<string, object>)
                        {
                            JSONDictionarytoYAML((Dictionary<string, object>)oChild);
                            JSONDeserialized += "\r\n";  
                        }
                    }
                }
                else
                {
                    strOutput = o.ToString();
                    JSONDeserialized += strOutput;
                }
            }
            indentLevel--;
            return bSuccess;
        }
