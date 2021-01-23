    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication2 {
        interface ICommand {
            bool Execute( string action, params object[] parameters );
        }
        class Program {
            static void Main( string[] args ) {
                CommandChain l_chain1 = new CommandChain( new FirstCommand(), new SecondCommand() );
                CommandChain l_chain2 = new CommandChain( new SecondCommand(), new ThirdCommand() );
                // Chain 1
                if ( l_chain1.Execute( "first", (int) 1, (double) 1.1 ) )
                    Console.WriteLine( "Chain 1 executed First" );
                else
                    Console.WriteLine( "Chain 1 did not execute First" );
                if ( l_chain1.Execute( "second", (double) 1.2 ) )
                    Console.WriteLine( "Chain 1 executed Second" );
                else
                    Console.WriteLine( "Chain 1 did not execute Second" );
                if ( l_chain1.Execute( "third", "4", (int) 3 ) )
                    Console.WriteLine( "Chain 1 executed Third" );
                else
                    Console.WriteLine( "Chain 1 did not execute Third" );
                // Chain 2
                if ( l_chain2.Execute( "first", (int) 1, (double) 1.1 ) )
                    Console.WriteLine( "Chain 2 executed First" );
                else
                    Console.WriteLine( "Chain 2 did not execute First" );
                if ( l_chain2.Execute( "second", (double) 1.2 ) )
                    Console.WriteLine( "Chain 2 executed Second" );
                else
                    Console.WriteLine( "Chain 2 did not execute Second" );
                if ( l_chain2.Execute( "third", "4", (int) 3 ) )
                    Console.WriteLine( "Chain 2 executed Third" );
                else
                    Console.WriteLine( "Chain 2 did not execute Third" );
                Console.ReadKey( true );
            }
        }
        class CommandChain {
            private ICommand[] _commands;
            public CommandChain( params ICommand[] commands ) {
                _commands = commands;
            }
            public bool Execute( string action, params object[] parameters ) {
                foreach ( ICommand l_command in _commands ) {
                    if ( l_command.Execute( action, parameters ) )
                        return true;
                }
                return false;
            }
        }
        class FirstCommand : ICommand {
            public bool Execute( string action, params object[] parameters ) {
                if ( action == "first" &&
                    parameters.Length == 2 &&
                    parameters[0].GetType() == typeof( int ) &&
                    parameters[1].GetType() == typeof( double ) ) {
                    int i = (int) parameters[0];
                    double d = (double) parameters[1];
                    // do something
                    return true;
                } else
                    return false;
            }
        }
        class SecondCommand : ICommand {
            public bool Execute( string action, params object[] parameters ) {
                if ( action == "second" &&
                    parameters.Length == 1 &&
                    parameters[0].GetType() == typeof( double ) ) {
                    double d = (double) parameters[0];
                    // do something
                    return true;
                } else
                    return false;
            }
        }
        class ThirdCommand : ICommand {
            public bool Execute( string action, params object[] parameters ) {
                if ( action == "third" &&
                    parameters.Length == 2 &&
                    parameters[0].GetType() == typeof( string ) &&
                    parameters[1].GetType() == typeof( int ) ) {
                    string s = (string) parameters[0];
                    int i = (int) parameters[1];
                    // do something
                    return true;
                } else
                    return false;
            }
        }
    }
