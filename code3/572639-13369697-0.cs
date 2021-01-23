        public static void WriteError(string message, params string[] args) {
            writerTasks.Add(() => {
                var c = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message, args);
                Console.ForegroundColor = c;
            });
        }
