    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.OleDb;
    namespace MediaPlayer
    {
    public partial class Media : Form
    {
    // Use this connection string if your database has the extension .accdb
    private const String access7ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\MediaDatabase.accdb";
    // Use this connection string if your database has the extension .mdb
    private const String access2003ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MediaDatabase.mdb";
    // Data components
    private DataTable myDataTable;
    // Index of the current record
    private int currentRecord = 0;
    private void FillDataTable(string selectCommand)
    {
        currentRecord=0;    
        OleDbConnection myConnection = new OleDbConnection(access7ConnectionString);
        OleDbDataAdapter myAdapter = new OleDbDataAdapter(selectCommand, myConnection);
        myDataTable = new DataTable();
          
          
        try
        {
            myConnection.Open();
            myAdapter.SelectCommand.CommandText = selectCommand;
            myAdapter.Fill(myDataTable);
            myConnection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error in FillDataTable : \r\n" + ex.Message);
        }
        DisplayRow(currentRecord);
    }
    private void DisplayRow(int rowIndex)
    {
        // Check that we can retrieve the given row
        if (myDataTable.Rows.Count == 0)
            return; // nothing to display
        if (rowIndex >= myDataTable.Rows.Count)
            //resets the index to 0 when you get past the last record
            rowIndex=0;
        //if rowIndex is less then 0 set it to the last row
        if (rowIndex<0) 
            rowIndex = myDataTable.Rows.Count-1;
        
        // If we get this far then we can retrieve the data
        try
        {
            DataRow row = myDataTable.Rows[rowIndex];
            textBox1.Text = row["FilePath"].ToString();
            textBox2.Text = row["Subject"].ToString();
            textBox3.Text = row["Title"].ToString();
            textBox4.Text = row["Keywords"].ToString();
            textBox5.Text = row["MediaType"].ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error in DisplayRow : \r\n" + ex.Message);
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        {
            string command = "SELECT * FROM Media";
            //the try catch is in the FillDataTable method
            FillDataTable(command);
        }
    }
    
    private void label2_Click(object sender, EventArgs e)
    {
    }
    private void button2_Click(object sender, EventArgs e)
    {
       //assuming this cycles through the data
        currentRecord++;
        DisplayRow(currentRecord);
    }
    private void button6_Click(object sender, EventArgs e)
    {
       //assuming this resets the data
        currentRecord=0;
        this.DisplayRow(currentRecord);
    }
    }
   
