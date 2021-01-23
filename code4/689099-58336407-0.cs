C#
private static void WriteStream(string cmd, ShellStream stream)
{
      stream.WriteLine(cmd + "; echo this-is-the-end");
      while (stream.Length == 0)
           Thread.Sleep(500);
}
private static string ReadStream(ShellStream stream)
{
      StringBuilder result = new StringBuilder();
      string line;
      while ((line = stream.ReadLine()) != "this-is-the-end")
             result.AppendLine(line);
      return result.ToString();
}
private static void SwithToRoot(string password, ShellStream stream)
{
       // Get logged in and get user prompt
       string prompt = stream.Expect(new Regex(@"[$>]"));
       //Console.WriteLine(prompt);
       // Send command and expect password or user prompt
       stream.WriteLine("su - root");
       prompt = stream.Expect(new Regex(@"([$#>:])"));
       //Console.WriteLine(prompt);
       // Check to send password
       if (prompt.Contains(":"))
       {
            // Send password
            stream.WriteLine(password);
            prompt = stream.Expect(new Regex(@"[$#>]"));
            //Console.WriteLine(prompt);
        }
}
Sample:
C#
using (var client = new SshClient(server, username, password))
{
          client.Connect();
          List<string> commands = new List<string>();
          commands.Add("pwd");
          commands.Add("cat /etc/sudoers");
          ShellStream shellStream = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024);
          // Switch to root
          SwithToRoot("rootpassword", shellStream);
          // Execute commands under root account
          foreach (string command in commands) {
                  WriteStream(command, shellStream);
                  string answer = ReadStream(shellStream);
                  int index = answer.IndexOf(System.Environment.NewLine);
                  answer = answer.Substring(index + System.Environment.NewLine.Length);
                  Console.WriteLine("Command output: " + answer.Trim());
           }
           client.Disconnect();
}
* Some other explanation
> I don't know user2's or root's password
In setting of server, user can switch account without promting password
