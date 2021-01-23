     Page Language="C#" AutoEventWireup="true" CodeBehind="TestForm.aspx.cs" Inherits="TestApp.TestForm"
    
     !DOCTYPE html PUBLIC
     Reference Page ="~/TestForm.aspx" // Note: Removed all HTML tags
    protected void Upload_Click(object sender, EventArgs e)
    {
        String noPW = "C:\\Users\\David\\Desktop\\Doc1.docx";
        String pwProtected = "C:\\Users\\David\\Desktop\\Test.docx"; 
    //         if (isProtected(pwProtected))
    //             outcome.Text = ("Document Is Password Protected");
    //         else
    //             outcome.Text = ("Document Is NOT Password Protected");
        if (isProtected(noPW))
            outcome.Text = ("Document Is Password Protected");
        else
            outcome.Text = ("Document Is NOT Password Protected");
    }
