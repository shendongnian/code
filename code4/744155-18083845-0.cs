            string s = "hello\x0world";
            File.WriteAllText("foo.txt", s);
            string t;
            using (var f = new StreamReader("foo.txt"))
            {
                t = f.ReadToEnd();
            }
            Console.WriteLine(t == s);  // prints "True"
