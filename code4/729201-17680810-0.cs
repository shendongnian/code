        public interface IUpdateData
        {
          void UpdateData();
        }
        
        //your forms will all implement the interface
        public class Form2 : Form, IUpdateData
        {
           public void UpdateData()
           {
              //some implementation
           }
        }
        
        public class Form3 : Form, IUpdateData
        {
           public void UpdateData()
           {
              //some implementation
           }
        }
