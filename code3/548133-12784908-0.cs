		[HttpPost]
		public ActionResult Connect( TableOrViewItem rbl )
		{
			/* TEST SESSION FIRST*/
			if ( Session["connstr"] == null )
				return RedirectToAction( "Index" );
			else
			{
				ViewBag.Message = "";
				ViewBag.ConnectionString = Server.UrlDecode( Session["connstr"].ToString() );
				ViewBag.Server = ParseConnectionString( ViewBag.ConnectionString, "Data Source" );
				ViewBag.Database = ParseConnectionString( ViewBag.ConnectionString, "Initial Catalog" );
				ViewBag.Selected = Request["name"] != null ? Request["name"].ToString() : "";
				ViewBag.ObjectID = Request["id"] != null ? Request["id"].ToString() : "";
				using ( var dbo = new SqlObjectContext( ViewBag.ConnectionString ) )
				{
					
					// obtain this item's objectid
					string CurrentObjectId = Request["id"].ToString();
					int CurrentID = StringToInt( CurrentObjectId );
					// populate Checkbox Area
					var rawColumns = dbo.Set<SqlColumn>()
						.Where( column => column.ObjectId == CurrentID )
						.OrderBy( o => o.ColumnId )
						.ToList();
					string htmlColumns = string.Empty;
					foreach ( EF_Utility.Models.SqlColumn item in rawColumns )
					{
						htmlColumns += "<input checked=\"checked\" id=\"RadioButtonViewModel_CheckBox" 
							+ item.ColumnId + "\" name=\"CheckBox_" + item.ColumnId 
							+ "\" type=\"checkbox\" value=\"" + item.Name + "\">" 
							+ item.Name + " <br>";
					}
					if(! string.IsNullOrEmpty(htmlColumns))
					{
						htmlColumns += "<br /><center><input type=\"submit\" value=\"Generate\" name=\"btnGenerate\" id=\"btnGenerate\" /></center>";
						htmlColumns += "<input type=\"hidden\" name=\"id\" value=\"" + CurrentObjectId + "\" />";
						htmlColumns += "<input type=\"hidden\" name=\"name\" value=\"" + ViewBag.Selected + "\" />";
					}
					ViewBag.TextBoxes = htmlColumns;
					/*var ColumnItemList = columns
						.Select( c => new ColumnItem { Name = c.Name, Selected = true, ObjectId = c.ObjectId } )
						.Where( tvi => tvi.ObjectId == CurrentID );
					*/
					// Check to see if the user wants the list generated
					if(Request["btnGenerate"] != null)
					{
						string sNewLine = System.Environment.NewLine;
						string htmlText = "[Table( \"" + ViewBag.Selected +"\" )]" + sNewLine +
							"public class " + POCOFormated( ViewBag.Selected ) + sNewLine + "{";
						string tempColumn = string.Empty;
						string tempName = string.Empty;
						foreach(string key in Request.Form)
						{
							if(!key.StartsWith("CheckBox_")) continue;
							
							tempName = POCOFormated( Request.Form[key] );
							htmlText = htmlText +
								sNewLine + "\t" +
								"public " + "...fieldtype..." + " " + tempName.Trim() + " { get; set; }" +
								sNewLine; 
						}						
						htmlText = htmlText + sNewLine + "}";
						ViewBag.TextArea = htmlText;
					}
						
					var objects = dbo.Set<SqlObject>().ToArray();
					
					var model = objects
						.Select( o => new TableOrViewItem { Name = o.Name, Selected = false, ObjectId = o.ObjectId } )
						.OrderBy( rb => rb.Name );
					
					return View( model );
				}
			}
		}
