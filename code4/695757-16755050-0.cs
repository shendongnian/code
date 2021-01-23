    string data = "S08A07934068721";                // results
    string data1 = data.Substring(4);               //   07934068721
    // test if padding correctly
    string padded = data1.PadLeft(13, '0');         // 0007934068721
    // textbox tbPadded is empty before adding text  
    tbPadded.AppendText(data1);                     //   07934068721
    // pad text
    tbPadded.Text = tbPadded.Text.PadLeft(13, '0'); // 0007934068721
            
   
