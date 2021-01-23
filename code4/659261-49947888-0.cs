            var text = File.ReadAllText("filename.json");
            var json = JsonValue.Parse(text);
            while (JsonValue.Null != null)
            {
                Console.WriteLine(json.ToString());
            }
            Console.ReadLine();
