    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace filedetection
    {
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\projects\projectsfortest\BusinessTest";
            DirectoryInfo d = new DirectoryInfo(path);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.cs"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {                
                Program program = new Program();
                List<string> allmethord = program.GetAllMethodNames(path+"\\"+file.Name);
                foreach (string methord in allmethord)
                {
                    Console.WriteLine(methord);
                }
            }
            
            Console.ReadKey();
        }
        public List<string> GetAllMethodNames(string strFileName)
        {
            List<string> methodNames = new List<string>();
            var strMethodLines = File.ReadAllLines(strFileName)
                                        .Where(a => (a.Contains("protected") ||
                                                    a.Contains("private") ||
                                                    a.Contains("public")) &&
                                                    !a.Contains("_") && !a.Contains("class"));
            foreach (var item in strMethodLines)
            {
                if (item.IndexOf("(") != -1)
                {
                    string strTemp = String.Join("", item.Substring(0, item.IndexOf(")")+1).Reverse());
                    strTemp = String.Join("", strTemp.Substring(0, strTemp.IndexOf("  ")).Reverse());
                    methodNames.Add(strTemp);                    
                }
            }
            return methodNames.Distinct().ToList();
        }
      }
    }
