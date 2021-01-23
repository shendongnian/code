    using System;
    using System.IO;
    
    namespace StackOverflowPreprocessor
    {
       /// <summary>
       /// This is a C# preprocessor program to demonstrate how you can use a preprocessor to modify the 
       /// C# source code in a program so it gets self-referential strings placed in it.
       /// </summary>
       public class PreprocessorProgram
       {
          /// <summary>
          /// The Main() method is where it all starts, of course. 
          /// </summary>
          /// <param name="args">must be one argument, the full name of the .csproj file</param>
          /// <returns>0 = OK, 1 = error (error message has been written to console)</returns>
          static int Main(string[] args)
          {
             try
             {
                // Check the argument
                if (args.Length != 1)
                {
                   DisplayError("There must be exactly one argument.");
                   return 1;
                }
    
                // Check the .csproj file exists
                if (!File.Exists(args[0]))
                {
                   DisplayError("File '" + args[0] + "' does not exist.");
                   return 1;
                }
    
                // Loop to process each C# source file in same folder as .csproj file. Alternative 
                //  technique (used in my real preprocessor program) is to read the .csproj file as an 
                //  XML document and process the <Compile> elements.
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(args[0]));
                foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.cs"))
                {
                   if (!ProcessOneFile(fileInfo.FullName))
                      return 1;
                }
             }
             catch (Exception e)
             {
                DisplayError("Exception while processing .csproj file '" + args[0] + "'.", e);
                return 1;
             }
    
             Console.WriteLine("Preprocessor normal completion.");
             return 0; // All OK
          }
    
    
          /// <summary>
          /// Method to do very simple preprocessing of a single C# source file. This is just "proof of 
          /// concept" - in my real preprocessor program I use regex and test for many different things 
          /// that I recognize and process in one way or another.
          /// </summary>
          private static bool ProcessOneFile(string fileName)
          {
             bool fileModified = false;
             string lastMethodName = "*unknown*";
             int i = -1, j = -1;
    
             try
             {
                string[] sourceLines = File.ReadAllLines(fileName);
                for (int lineNumber = 0; lineNumber < sourceLines.Length - 1; lineNumber++)
                {
                   string sourceLine = sourceLines[lineNumber];
                   
                   if (sourceLine.Trim() == "//?GrabMethodName")
                   {
                      string nextLine = sourceLines[++lineNumber];
                      j = nextLine.IndexOf('(');
                      if (j != -1)
                         i = nextLine.LastIndexOf(' ', j);
                      if (j != -1 && i != -1 && i < j)
                         lastMethodName = nextLine.Substring(i + 1, j - i - 1);
                      else
                      {
                         DisplayError("Unable to find method name in line " + (lineNumber + 1) + 
                                      " of file '" + fileName + "'.");
                         return false;
                      }
                   }
    
                   else if (sourceLine.Trim() == "//?DumpNameInStringAssignment")
                   {
                      string nextLine = sourceLines[++lineNumber];
                      i = nextLine.IndexOf('\"');
                      if (i != -1 && i != nextLine.Length - 1)
                      {
                         j = nextLine.LastIndexOf('\"');
                         if (i != j)
                         {
                            sourceLines[lineNumber] = 
                                        nextLine.Remove(i + 1) + lastMethodName + nextLine.Substring(j);
                            fileModified = true;
                         }
                      }
                   }
                }
    
                if (fileModified)
                   File.WriteAllLines(fileName, sourceLines);
             }
             catch (Exception e)
             {
                DisplayError("Exception while processing C# file '" + fileName + "'.", e);
                return false;
             }
             
             return true;
          }
    
          
          /// <summary>
          /// Method to display an error message on the console. 
          /// </summary>
          private static void DisplayError(string errorText)
          {
             Console.WriteLine("Preprocessor: " + errorText);
          }
    
    
          /// <summary>
          /// Method to display an error message on the console. 
          /// </summary>
          internal static void DisplayError(string errorText, Exception exceptionObject)
          {
             Console.WriteLine("Preprocessor: " + errorText + " - " + exceptionObject.Message);
          }
       }
    }
