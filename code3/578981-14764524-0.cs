    using System;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Collections.Generic;
    namespace WindowsFormsApplication2
    {
    public partial class Form1 : Form
    {
    public Form1()
    {
    InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
    this.richTextBox1.Text = "I am a string";
    }
    private void button1_Click(object sender, EventArgs e)
    {
    if (button1.Text == "Convert to Hex")
    {
    this.LocalString = this.richTextBox1.Text;
    ConvertToByteArray(this.LocalString);
    this.button1.Text = "Convert to String";
    }
    else
    {
    string HexString = this.richTextBox1.Text.Trim();
    HexString = HexString.Replace("'", "");
    ConvertToString(HexString);
    this.button1.Text = "Convert to Hex";
    }
    }
    private byte[] LocalByteArray = new byte[50];
    private string LocalString = string.Empty;
    private void ConvertToByteArray(string myString)
    {
    // Convert the String passed to a Byte Array for Hex Conversion...
    this.LocalByteArray = Encoding.UTF8.GetBytes(myString);
    // Create a new StringBuilder Reference...
    StringBuilder stringBuilder = new StringBuilder();
    // Append Start Char...
    stringBuilder.Append("'");
    // Loop through and append each converted Byte (Converted to Hex) to the String that we are building...
    foreach (byte b in this.LocalByteArray)
    {
    stringBuilder.Append(b.ToString("X2"));
    }
    // Append End Char...
    stringBuilder.Append("'");
    // Assign the String to TextBox...
    this.richTextBox1.Text = stringBuilder.ToString();
    }
    private void ConvertToString(string HexString)
    {
    // Create a new StringBuilder Reference...
    StringBuilder stringBuilder = new StringBuilder();
    // Loop through and append each converted Byte (Converted from Hex) to the String that we are building...
    for (int i = 0; i <= HexString.Length - 2; i += 2)
    {
    stringBuilder.Append(Convert.ToString(Convert.ToChar(Int32.Parse(HexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
    }
    // Assign the String to TextBox...
    this.richTextBox1.Text = stringBuilder.ToString();
    }
    }
    }
