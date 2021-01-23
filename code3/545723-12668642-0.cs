     <asp:ListView ID="ListView1" runat="server">
        <ItemTemplate> 
        <asp:Label Text='<%#Eval("n1")%>' runat="server"></asp:Label>
        </ItemTemplate>
        </asp:ListView>
    
      public class Person
        {
            public string n1 { get; set; }
            public string n2 { get; set; }
        }
    
            List<Person> list = new List<Person>();
            list.Add(new Person { n1 = "A", n2 = "A" });
            list.Add(new Person { n1 = "B", n2 = "B" });
            list.Add(new Person { n1 = "C", n2 = "C" });
            list.Add(new Person { n1 = "D", n2 = "D" });
            list.Add(new Person { n1 = "E", n2 = "E" });
    
            ListView1.DataSource = list;     
            ListView1.DataBind();
