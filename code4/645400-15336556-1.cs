    public class Parsedata
    {
         private string[,] m_ParticipantX;
         public void ParsedataMethod()
         {
           ...
           m_ParticipantX = new string[40, 4];//Neccesary data are added to this array
         }
         public string[,] ParticipantX
         {
              get { return m_ParticipantX; }
         }
    }
    using Crestron.ActiveCNX;
    public partial class Form1 : Form
    {
        ActiveCNX cnx;
        cnx = new ActiveCNX();
        Parsedata data = new Parsedata();
        private void SerialSend_Click(object sender, EventArgs e)
        {
            data.ParseDataMethod();
            int number = 8;
            for (int i = 1; i < number; i++)
                cnx.SendSerial(i, data.ParticipantX[i, 1]); //
        }
    }
