    using System.Reflection;
    
      public class AssemblyName_GetAssemblyName
    {
       public static void Main()
       {
          // Replace the string "MyAssembly.exe" with the name of an assembly,
          // including a path if necessary. If you do not have another assembly
          // to use, you can use whatever name you give to this assembly.
          //
         try     
         {   
                AssemblyName myAssemblyName = AssemblyName.GetAssemblyName("MyAssembly.exe");
         }       
         catch (BadImageFormatException ex)       
         {       
           ...                      
         } 
       }
    }
