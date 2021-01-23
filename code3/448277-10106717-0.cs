    <%@ Page Language="C#" %>
    <%@ Import Namespace="Panel=Ext.Net.Panel" %>
    <%@ Import Namespace="Button=Ext.Net.Button" %>
    <%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                this.Form.Controls.Add(this.BuildForm());
            }
        }
        private Component BuildForm()
        {
            var panel = new FormPanel {
                Title = "Example",
                Width = 350,
                Height = 215,
                Padding = 5,
                DefaultAnchor = "100%",
                Buttons = { new Button { Text = "Submit" }}
            };
            panel.Items.Add(this.BuildWidget(new Widget {
                Name = "text",
                ID = "TextField1",
                Label = "My TextField"
            }));
            panel.Items.Add(this.BuildWidget(new Widget {
                Name = "date",
                ID = "DateField1",
                Label = "My DateField"
            }));
            return panel;
        }
    
        private Field BuildWidget(Widget widget)
        {
            Field field = null;
        
            switch(widget.Name)
            {
                case "text":
                    field = new TextField(); 
                    break;
                case "date":
                    field = new DateField();
                    break;
            }
        
            field.ID = widget.ID;
            field.FieldLabel = widget.Label;
            return field;
        }
    
        public class Widget
        {
            public string Name { get; set; }
        
            public string ID { get; set; }
            public string Label { get; set; }
        }
    </script>
    <!DOCTYPE html>
    
    <html>
    <head runat="server">
        <title>Ext.NET Example</title>
    </head>
    <body>
        <form runat="server">
            <ext:ResourceManager runat="server" />
        </form>
    </body>
    </html>
