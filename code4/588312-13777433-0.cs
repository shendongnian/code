    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Reflection;
    
    namespace ConsoleApplication23
    {
        class Program
        {
            private static ConsoleKeyInfo keyAction1, keyAction2, keyAction3;
    
            static void Main(string[] args)
            {
                InitializeKeyActions();
    
                Console.Write("Do you want a new key action for #1? ");
                var result = Console.ReadKey();
                if (result.Key != ConsoleKey.Enter) { UpdateKeyInfo("keyAction1", result); }
            }
    
            private static void UpdateKeyInfo(string keyName, ConsoleKeyInfo result)
            {
                var propertyInfo = typeof(Program).GetField(keyName, BindingFlags.NonPublic | BindingFlags.Static);
                if (propertyInfo == null) { return; }
    
                var key = result.KeyChar;
                propertyInfo.SetValue(null, new ConsoleKeyInfo(key, (ConsoleKey)key, false, false, false));
    
                StringBuilder keyActions = new StringBuilder();
    
                foreach (var line in File.ReadAllLines("keyactions.ini"))
                {
                    var kvp = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (kvp[0] != keyName)
                    {
                        keyActions.AppendLine(line);
                        continue;
                    }
    
                    keyActions.AppendLine(string.Format("{0}: {1}", kvp[0], result.KeyChar));
                }
    
                File.WriteAllText("keyactions.ini", keyActions.ToString());
            }
    
            private static void InitializeKeyActions()
            {
                if (!File.Exists("keyactions.ini"))
                {
                    StringBuilder keyActions = new StringBuilder();
                    keyActions.AppendLine("keyAction1: A");
                    keyActions.AppendLine("keyAction2: B");
                    keyActions.AppendLine("keyAction3: C");
    
                    File.WriteAllText("keyactions.ini", keyActions.ToString());
                }
    
                foreach (var line in File.ReadAllLines("keyactions.ini"))
                {
                    var kvp = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
    
                    var propertyInfo = typeof(Program).GetField(kvp[0], BindingFlags.NonPublic | BindingFlags.Static);
                    if (propertyInfo == null) { continue; }
    
                    var key = kvp[1].Trim()[0];
                    propertyInfo.SetValue(null, new ConsoleKeyInfo(key, (ConsoleKey)key, false, false, false));
                }
            }
        }
    }
