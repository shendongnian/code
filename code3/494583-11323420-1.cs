            String str = "Dialogue: 0,0:00:01.99,0:00:03.84,Default,,0000,0000,0000,,Up you go!";
            String newStr = Regex.Replace(str, "(.*,,)(.*)$", "$1{$2}");
            System.Console.WriteLine(str);
            System.Console.WriteLine(newStr);
            System.Console.ReadKey();
