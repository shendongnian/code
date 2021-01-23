    public class CategoryPicker : Control, IContentField
    	{
    		#region IContentField Implementation
    
    		public string GetValue()
    		{
    			return string.Format("{0}|{1}",
    			                     GetInputControl<Listbox>(ControlNames.MainCategoryDropList).SelectedItem.Value,
    			                     GetInputControl<Listbox>(ControlNames.SubCategoryDropList).SelectedItem.Value);
    
    		}
    
    		public void SetValue(string value)
    		{
    			Value = value;
    		}
    
    		#endregion
    
    		#region Properties
    
    		public string ItemId
    		{
    			get { return GetViewStateString("ItemID"); }
    			set { SetViewStateString("ItemID", value); }
    		}
    
    		private CategoryIdPair CategoryIdPair
    		{
    			get
    			{
    				Item contextItem = GetItem(ItemId);
    				if (contextItem.Fields["CategoryId"] != null)
    				{
    					return CategoryFieldParser.Parse(contextItem.Fields["CategoryId"].Value);
    				}
    				return CategoryIdPair.Empty;
    			}
    		}
    
    		public bool TrackModified
    		{
    			get { return GetViewStateBool("TrackModified", false); }
    			set { SetViewStateBool("TrackModified", value, false); }
    		}
    
    		#endregion
    
    		public CategoryPicker()
    		{
    			TrackModified = true;
    		}
    
    		protected override void OnLoad(EventArgs e)
    		{
    			if (!Sitecore.Context.ClientPage.IsEvent)
    			{
    				Controls.Clear();
    				Controls.Add(CreateMainCategorySelectorControl());
    				Controls.Add(CreateSubCategorySelectorControl());
    
    				SetSelectorOnChangeEvents();
    			}
    			else
    			{
    				var mainCategorySelectorControl = GetInputControl<Listbox>(ControlNames.MainCategoryDropList);
    				var subCategorySelectorControl = GetInputControl<Listbox>(ControlNames.SubCategoryDropList);
    				// if value changed - set modified=true
    				if (mainCategorySelectorControl.SelectedItem.Value != CategoryIdPair.CategoryId.ToString() || subCategorySelectorControl.SelectedItem.Value != CategoryIdPair.SubCategoryId.ToString())
    				{
    					SetModified();
    				}
    			}
    
    			base.OnLoad(e);
    		}
    
    		private void SetSelectorOnChangeEvents()
    		{
    			var mainCategorySelectorControl = GetInputControl<Listbox>(ControlNames.MainCategoryDropList);
    			mainCategorySelectorControl.Attributes.Add("onchange",
    			                                           Sitecore.Context.ClientPage.GetClientEvent(
    			                                           	ID + ".ReInitialiseSubCategorySelector"));
    			var subCategorySelectorControl = GetInputControl<Listbox>(ControlNames.SubCategoryDropList);
    			subCategorySelectorControl.Attributes.Add("onchange",
    			                                          Sitecore.Context.ClientPage.GetClientEvent(
    			                                          	ID + ".SetSubCategoryFieldValue"));
    		}
    
    		public void ReInitialiseSubCategorySelector()
    		{
    			var subCategorySelectorControl = GetInputControl<Listbox>(ControlNames.SubCategoryDropList);
    			InitialiseSubCategorySelectorControl(subCategorySelectorControl);
    			Sitecore.Context.ClientPage.ClientResponse.Refresh(subCategorySelectorControl);
    		}
    
    		public void SetSubCategoryFieldValue()
    		{
    			Item contextItem = GetItem(ItemId);
    			using (new SecurityDisabler())
    			{
    				contextItem.Editing.BeginEdit();
    				contextItem.Fields["CategoryId"].Value = GetValue();
    				contextItem.Editing.EndEdit();
    			}	
    		}
    
    		#region Main Category Dropdown Population
    
    		private Listbox CreateMainCategorySelectorControl()
    		{
    			var mainCategorySelectorControl = new Listbox
    			                                  	{
    			                                  		ID = GetID(ControlNames.MainCategoryDropList),
    			                                  		Disabled = Disabled,
    			                                  		TrackModified = false
    			                                  	};
    
    			InitialiseMainCategorySelectorControl(mainCategorySelectorControl);
    
    			return mainCategorySelectorControl;
    		}
    
    		private void InitialiseMainCategorySelectorControl(System.Web.UI.Control mainCategorySelectorControl)
    		{
    			List<Category> mainCategories = //Get main categories;
    			
    			foreach (Category category in mainCategories)
    				CreateCategoryListItem(category.Description, category.CategoryId, mainCategorySelectorControl, category.CategoryId == CategoryIdPair.CategoryId);
    		}
    
    		#endregion
    
    		#region Sub-Category Dropdown Population
    
    		public Listbox CreateSubCategorySelectorControl()
    		{
    			var subCategorySelectorControl = new Listbox
    			                                 	{
    			                                 		ID = GetID(ControlNames.SubCategoryDropList),
    			                                 		Disabled = Disabled,
    			                                 		TrackModified = false
    			                                 	};
    
    			InitialiseSubCategorySelectorControl(subCategorySelectorControl);
    			subCategorySelectorControl.Value = CategoryIdPair.SubCategoryId.ToString();
    			Sitecore.Context.ClientPage.ClientResponse.Refresh(subCategorySelectorControl);
    			return subCategorySelectorControl;
    		}
    
    		public void InitialiseSubCategorySelectorControl(System.Web.UI.Control subCategorySelectorControl)
    		{
    			var mainCategorySelectorControl = GetInputControl<Listbox>(ControlNames.MainCategoryDropList);
    			int mainCategorySelectedValue = Convert.ToInt32(mainCategorySelectorControl.SelectedItem.Value);
    
    			subCategorySelectorControl.Controls.Clear();
    
    			CreateCategoryListItem("Please select", 0, subCategorySelectorControl, false);
    
    			List<SubCategory> subCategories = //Get all subcategories
    			foreach (SubCategory subCategory in subCategories)
    			{
    				CreateCategoryListItem(subCategory.Description, subCategory.SubCategoryId, subCategorySelectorControl, subCategory.SubCategoryId == CategoryIdPair.SubCategoryId);
    			}
    		}
    
    		#endregion
    
    		private static void CreateCategoryListItem(string title, int value, System.Web.UI.Control control, bool selected)
    		{
    			var listItem = new ListItem
    			               	{
    			               		ID = GetUniqueID(ControlNames.CategoryListItem),
    			               		Header = title,
    			               		Value = value.ToString(),
    								Selected = selected
    			               	};
    
    			Sitecore.Context.ClientPage.AddControl(control, listItem);
    		}
    
    		#region Helper Methods
    
    		private T GetInputControl<T>(string controlName) where T : Control
    		{
    			return FindControl(GetID(controlName)) as T;
    		}
    
    		private void SetModified()
    		{
    			if (TrackModified)
    			{
    				Sitecore.Context.ClientPage.Modified = true;
    			}
    		}
    
    		private static Item GetItem(string itemId)
    		{
    			return Sitecore.Context.ContentDatabase.GetItem(new ID(itemId));
    		}
    
    		#endregion
    
    		#region ControlNames Nested Class
    		
    		private static class ControlNames
    		{
    			public const string MainCategoryDropList = "MainCategoryDropList";
    			public const string SubCategoryDropList = "SubCategoryDropList";
    			public const string CategoryListItem = "CategoryListItem";
    		}
    
    		#endregion
    	}
    	
    	public class CategoryField : CustomField
    	{
    		public int CategoryId { get; set; }
    		public int SubCategoryId { get; set; }
    
    		public CategoryField(Field innerField) : base(innerField)
    		{
    			Assert.ArgumentNotNull(innerField, "innerField");
    			var pair = CategoryFieldParser.Parse(innerField.Value);
    			CategoryId = pair.CategoryId;
    			SubCategoryId = pair.SubCategoryId;
    		}
    
    		public static implicit operator CategoryField(Field field)
    		{
    			if (field != null)
    			{
    				return new CategoryField(field);
    			}
    			return null;
    		}
    	}
    
    	public class CategoryFieldParser
    	{
    		public static CategoryIdPair Parse(string input)
    		{
    			var pair = input.Split(new[] { '|' });
    			return new CategoryIdPair
    			       	{
    						CategoryId = pair.Length > 0 ? GetIntValue(pair[0]) : CategoryIdPair.Empty.CategoryId,
    						SubCategoryId = pair.Length == 2 ? GetIntValue(pair[1]) : CategoryIdPair.Empty.SubCategoryId
    			       	};
    		}
    
    		private static int GetIntValue(string input)
    		{
    			int result;
    			if (int.TryParse(input, out result))
    				return result;
    			return 0;
    		}
    	}
    
    	public class CategoryIdPair
    	{
    		public int CategoryId { get; set; }
    		public int SubCategoryId { get; set; }
    		public static CategoryIdPair Empty
    		{
    			get { return new CategoryIdPair {CategoryId = 0, SubCategoryId = 0}; }
    		}
    	}
