    <#@ template language="C#" #>
    namespace Application
    {
      class Program
      {
         static void Main()
         {
           byte[] buffer = new byte[1024] { <#= BufferValue.Select(b => "0x" + b.ToString("X2")).Aggregate((f, s) => f + ", " + s) #> };
           //And some code for creating a file with the bytes in the buffer.
         }
      }
    }
    <#+
    
    public byte[] BufferValue { get; set; } 
    
    #>
