    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Text;
    using Microsoft.SqlServer.Management.Common;
    
    namespace ScriptParser
    {
       class Program
       {
          static void Main(string[] args)
          {
             ExecuteBatch batcher = new ExecuteBatch();
             string text = File.ReadAllText(@"Path_To_My_Long_Sql_File.sql");
             StringCollection statements = batcher.GetStatements(text);
             foreach (string statement in statements)
             {
                Console.WriteLine(statement);
             }
          }
       }
    }
