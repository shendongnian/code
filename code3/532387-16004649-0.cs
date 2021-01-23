    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Timers;
    namespace testconsole
    {
        class Program
        {
            private static bool Running = true;
            private static string Command = "";
            static void Main( string[] args )
            {
                while ( Running )
                {
                    ReadInput();
                }//running
            }//main-----------------------------------------
            static void ReadInput()
            {
                ConsoleKeyInfo cki;
                cki = Console.ReadKey();
                if ( cki.Key == ConsoleKey.Escape )
                {
                    Command = "";
                }
                else if (cki.Key == ConsoleKey.Backspace)
                {
                    ClearConsole();
                    if ( Command.Length > 0 )
                    {
                        Command = Command.Substring( 0, Command.Length - 1 );
                    }
                    Console.CursorLeft = 0;
                    Console.Write( Command );
                }
                else if ( cki.Key == ConsoleKey.Enter )
                {
                    Console.CursorLeft = 0;
                    ClearConsole();
                    string TempCommand = Command;
                    TextOut( Command );
                    Command = "";
                    //process tempcommand
                    if ( TempCommand  == "quit")
                    {
                        Running = false;
                    }
                    if ( TempCommand == "test" )
                    {
                        TextOut("this is a test");
                    }
                }
                else
                {
                    Command += cki.KeyChar;
                    Console.CursorLeft = 0;
                    Console.Write( Command );
                }
            }//ReadInput-----------------------------------------
            static void ClearConsole()
            {
                for ( int i = 0; i < Command.Length; i++ )
                {
                    Console.Write( " " );
                }
            }//ClearConsole-----------------------------------------
            static void TextOut( string Message )
            {
                if (Command != "")
                {
                    ClearConsole();
                }
                Console.CursorLeft = 0;
                Console.WriteLine( Message );
                if ( Message != Command )
                {
                    Console.Write( Command );
                }
            }//TextOut-----------------------------------------
        }//program
    }//namespace
