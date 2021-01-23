    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
        <link href="Scripts/css/ui-lightness/jquery-ui-1.8.20.custom.css" rel="stylesheet"
            type="text/css" />
        <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
        <script src="Scripts/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
        <script type="text/javascript">
            $.fx.speeds._default = 1000;
            $(document).ready(function () {
                $("div[id*='window']").live('click', function (e) {
                    $.ajax({
                        url: "WebService.asmx/GetCompanyDetails", type: "Post", dataType: "json",
                        data: JSON.stringify({ id: $(this).attr('id').replace(/window/g, '') }),
                        contentType: "application/json; charset=utf-8",
                        success: function (msg) {
                            var data = $.parseJSON(JSON.stringify(eval("(" + msg.d + ")")));
    
                            $('<div></div>').appendTo('body').html('<div>' + data.Name + '</div><div>' + data.City + '</div>').dialog({
                                modal: true, title: 'Test message', zIndex: 10000, autoOpen: true,
                                width: 460, height: 300, modal: true, resizable: false, closeOnEscape: false,
                                show: "slide", hide: "explode",
                                buttons: {
                                    Ok: function () {
                                        $(this).dialog("close");
                                    }
                                },
                                close: function (event, ui) {
                                    $(this).remove();
                                }
                            });
                        },
                        error: function (msg) {
    
                        }
                    });
                });
            });
        </script>
    </head>
    <body>
        <div id="window1">
            Test1
        </div>
        <br />
        <br />
        <br />
        <br />
        <div id="window2">
            Test2
        </div>
    </body>
    </html>
    
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Entity;
    
    namespace CompanyDisplay
    {
        public partial class CompayJqueryUI : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
    
            public Company GetCompanyDetails(int id)
            {
                if (true)   //authorize 
                {
                    //SqlConnection cn = new SqlConnection(@"Data Source=KURIOS_WS4;Initial Catalog=Dreams;User ID=sa;Password=SageCRMv71");
                    //string qry = "Select comp_companyId,comp_name,comp_status from Company where comp_companyId=@comp_companyId ";
                    //SqlCommand cmd = new SqlCommand(qry, cn);
                    //SqlDataReader reader = cmd.ExecuteReader();
    
                    Company entity = new Company();
                    entity.Id = 2;
                    entity.Name = "Test";
                    entity.City = "Bangalore";
    
                    //Or
    
                    //if (reader.Read())
                    //{
                    //    entity.Id = int.Parse(reader["comp_companyId"].ToString());
                    //    entity.Name = reader["comp_name"].ToString();
                    //    entity.City = reader["comp_status"].ToString();
                    //}
    
                    return entity;
                }
                else
                {
                    return new Company();
                }
            }
        }
    }
    
    
    
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Services;
    using System.Web.Script.Serialization;
    using CompanyDisplay;
    
    namespace CompanyDisplay
    {
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        [ScriptService]
        public class WebService : System.Web.Services.WebService
        {
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public string GetCompanyDetails(int id)
            {
                return new JavaScriptSerializer().Serialize(new CompayJqueryUI().GetCompanyDetails(id));
            }
        }
    }
