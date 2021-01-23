       using System; 
       using Novacode; 
       using System.Drawing; 
         
       namespace DocXHelloWorld 
       { 
           class Program 
           { 
               static void Main(string[] args) 
               { 
                   using (DocX document = DocX.Create("Test.docx")) 
                   { 
                       // Add a new Paragraph to the document. 
                       Paragraph p = document.InsertParagraph();
                       
                       // Append some text. 
                       p.Append("Hello World").Font(new FontFamily("Arial Black")); 
         
                       // Save the document. 
                       document.Save(); 
                   } 
               } 
           }
