    using System;
    
    using System.Data.SqlClient;
    
    using System.Data.SqlTypes;
    using System.Data.OracleClient; //Add This
    using System.Collections.Generic;
    
    using System.Data.OleDb;
    
    using System.Linq;
    
    using System.Web;
    
    using System.Data;
    
    using System.Configuration;
    
    using System.Web.UI;
    
    using System.Web.UI.WebControls;
    
    using System.Web.UI.WebControls.WebParts;
    
    using System.Web.UI.HtmlControls;
    
    namespace Foo {
    
    public class DBHandler
        {
    
            private readonly OracleConnection oracleConnection;
            private readonly OracleCommand oracleCommand;
            private readonly OracleDataAdapter oracleAdapter;
