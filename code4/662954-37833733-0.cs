    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace TESTNEW
    {
       public abstract class BusinessStructure
        {
           public BusinessStructure()
           { }
    
           public string Name { get; set; }
       public string[] PropertyNames{
           get
           { 
                    System.Reflection.PropertyInfo[] Pr;
                    System.Type _type = this.GetType();
                    Pr = _type.GetProperties();
                    string[] ReturnValue = new string[Pr.Length];
                    for (int a = 0; a <= Pr.Length - 1; a++)
                    {
                        ReturnValue[a] = Pr[a].Name;
                    }
                    return ReturnValue;
           }
       }
    }
   
    public class MyCLS : BusinessStructure
       {
           public MyCLS() { }
           public int ID { get; set; }
           public string Value { get; set; }
       
    
       }
       public class Test
       {
           void Test()
           {
               MyCLS Cls = new MyCLS();
               string[] s = Cls.PropertyNames;
               for (int a = 0; a <= s.Length - 1; a++)
               {
                System.Windows.Forms.MessageBox.Show(s[a].ToString());
               }
           }
       }
    }
