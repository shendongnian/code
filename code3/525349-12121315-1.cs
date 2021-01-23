    namespace myNet
    {
         class Program
         {
                int Main(string arg)
                {
                        //and here you can run your XML parser:
    
                        List<string> myList = XMLParse();
    
                        FileStream fs = new Filestream("xmllist.txt");
                        StreamWriter sw = new StreamWriter(fs);
    
                        foreach(string s in myList)
                             sw.WriteLine(s);
    
                        sw.Close();
                        fs.Close();
    
                        return 1;
                }
                List<string> XMLParse()
                {
                        //Your code here
                        return aList;
                }
         }
    
    }
