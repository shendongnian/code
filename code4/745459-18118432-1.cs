       public class FileStudentService:IStudentService{
            steing _filepath;
            Public FileStudentService(string filepath){
              _filepath = filepath;
            }
            
            public Dictionary<int, int> GetStudentData()
            {
                Dictionary<int, int> studentResultDict = new Dictionary<int, int>();
                foreach (var item in File.ReadAllLines(_filepath))
                {
                    string[] data = item.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    studentResultDict.Add(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]) + Convert.ToInt32(data[2]));
                }
    
            return studentResultDict;
            }
    
        }
