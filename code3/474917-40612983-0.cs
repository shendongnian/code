    using System;
    using System.Collections.Generic;
    using System.Threading;
    namespace PowerConsole {
        internal class Containers {
            internal struct Container {
                public int Id;
                public int X;
                public int Y;
                public string Content;
            }
            public static List<Container> Items = new List<Container>();
            private static int Identity = 0;
            public static int Add(string text) {
                var c = new Container();
                c.Id = Identity++;
                c.X = Console.CursorLeft;
                c.Y = Console.CursorTop;
                c.Content = text;
                Console.Write(text);
                Items.Add(c);
                return c.Id;
            }
            public static void Remove(int id) {
                Items.RemoveAt(id);
            }
            public static void Replace(int id, string text) {
                int x = Console.CursorLeft, y = Console.CursorTop;
                Container c = Items[id];
                Console.MoveBufferArea(
                    c.X + c.Content.Length, c.Y,
                    Console.BufferWidth - c.X - text.Length, 1,
                    c.X + text.Length, c.Y
                );
                Console.CursorLeft = c.X;
                Console.CursorTop = c.Y;
                Console.Write(text);
                c.Content = text;
                Console.CursorLeft = x;
                Console.CursorTop = y;
            }
            public static void Clear() {
                Items.Clear();
                Identity = 0;
            }
        }
        internal class Program {
            private static List<Thread> Threads = new List<Thread>();
            private static void Main(string[] args) {
                Console.WriteLine("So we have some threads:\r\n");
                int i, id;
                Random r = new Random();
                for (i = 0; i < 10; i++) {
                    Console.Write("Starting thread " + i + "...[");
                    id = Containers.Add("?");
                    Console.WriteLine("]");
                    Thread t = new Thread((object data) => {
                        Thread.Sleep(r.Next(5000) + 100);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Containers.Replace((int)data, "DONE");
                        Console.ResetColor();
                    });
                    Threads.Add(t);
                }
                Console.WriteLine("\n\"But will it blend?\"...");
                Console.ReadKey(true);
                i = 0;
                Threads.ForEach(t => t.Start(i++));
                Threads.ForEach(t => t.Join());
                Console.WriteLine("\r\nVoila.");
                Console.ReadKey(true);
            }
        }
    }
