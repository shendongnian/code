    [HttpGet]
            public ActionResult Dropdown()
            {  
                    MyViewModel model = GetDefaultModel();  
                    return View(model);
                }
            }
    
    
    public MyViewModel GetDefaultModel()
            {
                var entity = new MyViewModel();            
                entity.Status = GetMyDropdownValues();            
                return entity;
            }
    
    
    private List<KeyValueEntity> GetMyDropdownValues()
    		{
    			return new List<KeyValueEntity>
    			{
    				new KeyValueEntity { Description = "Yes" , Value ="1" },
    				new KeyValueEntity { Description = "No" , Value ="0"}
    			};
    		}
