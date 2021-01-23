    public class e{
    
    
            string ruta = "";
    
                    foreach(var readText in Directory.GetFiles(@"C:\dev\vsprojects\MvcApplication4\MvcApplication4", "stringCon.txt", SearchOption.AllDirectories)) {
    
                        ruta = readText;
                        ruta = ruta.Replace(@"\\", @"\");
        //in debugger mode says ruta parameter still having the \\ and i cant get the content of the txt file
                    TextReader ReadTXT_file = new StreamReader(ruta);
        //and here says that StringConexion is null, why??
                    string StringConexion = ReadTXT_file.ReadLine();//
    
                    ReadTXT_file.Close(); 
    
                    }
    
                    
    
    }
