    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using gudusoft.gsqlparser;
    using gudusoft.gsqlparser.Units;
    namespace findsubquerys
    {
        class prg
        {
            static void Main(string[] args)
            {
                int c = Environment.TickCount;
                if (args.Length == 0)
                {
                    Console.WriteLine("{0} scriptfile", "syntaxcheck");
                    return;
                }
                TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVMssql);
                sqlparser.Sqlfilename = args[0];
                int iRet = sqlparser.Parse();
                if (iRet == 0)
                {
                    foreach (TCustomSqlStatement stmt in sqlparser.SqlStatements)
                    {
                        printStmt(stmt);
                    }
                }
                else
                {
                    Console.WriteLine("Syntax error found in input sql:");
                    Console.WriteLine(sqlparser.ErrorMessages);
                }
            }
            static void printStmt(TCustomSqlStatement pstmt)
            {
                Console.WriteLine(pstmt.AsText+"\n");
                for (int j = 0; j < pstmt.ChildNodes.Count(); j++)
                {
                    if (pstmt.ChildNodes[j] is TCustomSqlStatement)
                    {
                        printStmt((TCustomSqlStatement)(pstmt.ChildNodes[j]));
                    }
                }
            }
        } //class
    }
