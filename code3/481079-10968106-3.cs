    public class Program
    {
        public static void Main(string[] args)
        {
            ModemReader r = new ModemReader();
            r.StartReading();
        }
        class ModemReader{
            string buff="";
            public void StartReading()
            {
                string ok = "OK";
                SerialPort p = new SerialPort("COM28");
                p.DataReceived += new SerialDataReceivedEventHandler(p_DataReceived);
                p.Open();
                string line = "1";
                p.Write("AT" + "\r");
                Console.WriteLine("buff: \"{0}\"\nok: \"{1}\"", buff, ok);
                p.Write("AT+CMGF=1"+ "\r" );
                Console.WriteLine("buff: \"{0}\"\nok: \"{1}\"", buff, ok);
                do
                {
                    // Clear the buffer here
                    buff = "";  
                    p.Write("AT+CMGL=\"REC UNREAD\" " + "\r");
                    Console.WriteLine("buff: \"{0}\"\nok: \"{1}\"", buff, ok);
                    if (buff.Contains(ok))
                        Console.WriteLine("Everything is OK");
                    else
                        Console.WriteLine("NOK");
                    line = Console.ReadLine();
                } while (line != "quit");
                p.Close();
            }
            public void p_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                string s = (sender as SerialPort).ReadExisting();
                buff += s;
                Console.WriteLine(s);
            }
        }
    } 
