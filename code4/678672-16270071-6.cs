    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.SqlServer.TransactSql.ScriptDom;
    
    namespace ScriptDomDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                TSql120Parser parser = new TSql120Parser(false);
                IList<ParseError> errors;
                using (StringReader sr = new StringReader(@"create table t1 (c1 int primary key)
    GO
    create table t2 (c1 int primary key)"))
                {
                    TSqlFragment fragment = parser.Parse(sr, out errors);
                    IEnumerable<string> batches = GetBatches(fragment);
                    foreach (var batch in batches)
                    {
                        Console.WriteLine(batch);
                    }
                }
            }
    
            private static IEnumerable<string> GetBatches(TSqlFragment fragment)
            {
                Sql120ScriptGenerator sg = new Sql120ScriptGenerator();
                TSqlScript script = fragment as TSqlScript;
                if (script != null)
                {
                    foreach (var batch in script.Batches)
                    {
                        yield return ScriptFragment(sg, batch);
                    }
                }
                else
                {
                    // TSqlFragment is a TSqlBatch or a TSqlStatement
                    yield return ScriptFragment(sg, fragment);
                }
            }
    
            private static string ScriptFragment(SqlScriptGenerator sg, TSqlFragment fragment)
            {
                string resultString;
                sg.GenerateScript(fragment, out resultString);
                return resultString;
            }
        }
    }
