    SPWeb mySite = SPContext.Current.Web;
    SPListItemCollection listItems = mySite.Lists[TextBox1.Text].Items;
    SPListItem item = listItems.Add();
    item["Title"] = TextBox2.Text;
    item["Stock"] = Convert.ToInt32(TextBox3.Text);
    item["Return Date"] = Convert.ToDateTime(TextBox4.Text);
    item["Employee"] = TextBox5.Text;
    item.Update();
    }
