    <asp:TextBox ID="txtAttributeTags" runat="server" />
    <asp:Button runat="server" ID="SubmitButton" OnClick="SubmitButton_Click" 
      Text="Submit" />
    
    public const int AttributeID = 1;
    
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        using (var db = new AttributeEntities())
        {
          var tags = db.AttributeTags
            .Where(a => a.attribute_id == AttributeID)
            .Select(a => a.value);
    
          txtAttributeTags.Text = string.Join(",", tags);
        }
      }
    }
    
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
      using (var db = new AttributeEntities())
      {
        string[] newTags = txtAttributeTags.Text.Split(new[] {","}, 
          StringSplitOptions.RemoveEmptyEntries);
    
        var oldTags = db.AttributeTags.Where(t => t.attribute_id == AttributeID);
    
        foreach (var tag in oldTags.Where(o => !newTags.Contains(o.value)))
            db.AttributeTags.DeleteObject(tag);
    
        foreach (var tag in newTags.Where(n => !oldTags.Any(o => o.value == n)))
          db.AttributeTags.AddObject(new AttributeTag
          {
              attribute_id = AttributeID, value = tag, timestamp = DateTime.Now
          });
    
        db.SaveChanges();
        }
      }
    }
