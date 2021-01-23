    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Text;
    
    namespace Whois
    {
      class Program
      {
        static void Main(string[] args)
        {
          string tldWhoisServer = "whois.iana.org";
          string ccTldServer, query = null;
          Console.Write("Query> ");
          while ((query = Console.ReadLine()) != string.Empty)
          {
            string tld = query.Substring(query.LastIndexOf('.') + 1);
            string foo = GetWhoisInformation(tldWhoisServer, tld);
            foo = foo.Remove(0, foo.IndexOf("whois:") + 6).TrimStart();
            ccTldServer = foo.Substring(0, foo.IndexOf('\r'));
            Console.WriteLine(GetWhoisInformation(ccTldServer, query));
            Console.Write("Query> ");
          } 
        }
        static string GetWhoisInformation(string whoisServer, string url)
        {
          try
          {
            StringBuilder stringBuilderResult = new StringBuilder();
            TcpClient tcpClinetWhois = new TcpClient(whoisServer, 43);
            NetworkStream networkStreamWhois = tcpClinetWhois.GetStream();
            BufferedStream bufferedStreamWhois = new BufferedStream(networkStreamWhois);
            StreamWriter streamWriter = new StreamWriter(bufferedStreamWhois);
    
            streamWriter.WriteLine(url);
            streamWriter.Flush();
    
            StreamReader streamReaderReceive = new StreamReader(bufferedStreamWhois);
    
            while (!streamReaderReceive.EndOfStream)
              stringBuilderResult.AppendLine(streamReaderReceive.ReadLine());
            return stringBuilderResult.ToString();
          }
          catch
          {
            return "Query failed";
          }
        }
      }
    }
