        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        
        namespace RepeaterTest
        {
            public class Car
            {
                private string _year;
                private string _make;
                private string _model;
        
                public string Year
                {
                    get
                    {
                        return _year;
                    }
                    set
                    {
                        _year = value;
                    }
                }
        
                public string Make {
                    get { return _make; }
                    set { _make=value;}
                }
        
                public string Model
                {
                    get { return _model; }
                    set { _model = value; }
                }
        
                public Car(string year,string make,string model){
                    _year = year;
                    _make = make;
                    _model = model;
            }
        
                public Car(){
            }
        
            }
        }
        
        
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Collections;
        
        namespace RepeaterTest
        {
            public class Cars:CollectionBase
            {
                
                public int Add(Car car) {
                    return List.Add(car);
                } 
        
            }
        }
        
        in code behind:
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        
        namespace RepeaterTest
        {
            public partial class WebForm1 : System.Web.UI.Page
            {
                protected void Page_Load(object sender, EventArgs e)
                {
                    if (!Page.IsPostBack) {
                        Cars cars = new Cars();
                        Car c1 = new Car("2011", "Marcedez", "Marcedez");
                        Car c2 = new Car("2012", "BMW", "135i");
                       cars.Add(c1);
                       cars.Add(c2);
                        Repeater1.DataSource = cars;
                        Repeater1.DataBind();
                    }
                }
        
                protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
                {
                    if (e.CommandName == "Add") {
                        Car carLastEntered = new Car();
                        Cars cars = new Cars();
                        foreach (RepeaterItem item in Repeater1.Items) {
                            Car car = new Car();
                            car.Year = ((TextBox)(item.FindControl("txtYear"))).Text;
                            car.Make = ((TextBox)(item.FindControl("txtMake"))).Text;
                            car.Model = ((TextBox)(item.FindControl("txtModel"))).Text;
                          cars.Add(car);
                          carLastEntered = car;
                            
                        }
                        
                        cars.Add(carLastEntered);
                        Repeater1.DataSource = cars;
                        Repeater1.DataBind();
        
                    }
                }
            }
        }
        
        in aspx:
        <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="RepeaterTest.WebForm1" %>
        
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        
        <html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
            <title></title>
        </head>
        <body>
            <form id="form1" runat="server">
            <div>
                <asp:Repeater ID="Repeater1" runat="server" 
                    onitemcommand="Repeater1_ItemCommand">
                 <HeaderTemplate>
                <table cellpadding="0" cellspacing="5">
                <tr style="padding-top: 5px;">
                    <td colspan="6">
                        <asp:Label ID="lblInstructions" runat="server" Text="Add your cars here:" />
                    </td>
                </tr>
                <tr runat="server" id="trHeader" style="font-weight: bold;">
                    <td>Year</td>
                    <td>Make</td>
                    <td>Model</td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>         
            </HeaderTemplate> 
            <ItemTemplate>
                <tr>
                    <td><asp:TextBox ID="txtYear" runat="server" Width="65" 
                         Text='<%#DataBinder.Eval(Container.DataItem, "Year")%>' /></td>
                    <td><asp:TextBox ID="txtMake" runat="server" Width="70"             
                         Text='<%#DataBinder.Eval(Container.DataItem, "Make")%>' /></td>
                    <td><asp:TextBox ID="txtModel" runat="server" Width="70" 
                         Text='<%#DataBinder.Eval(Container.DataItem, "Model")%>' /></td>
                </tr>
            </ItemTemplate> 
            <FooterTemplate>
                <tr style="padding-top: 5px;">
                   <td colspan="6">
                       <asp:Button ID="btnAdd" runat="server" 
                        Text="Add Car" CommandName="Add" />
                   </td>
                </tr>
                </table>
            </FooterTemplate>
                </asp:Repeater>
            </div>
            </form>
        </body>
        </html>
    
