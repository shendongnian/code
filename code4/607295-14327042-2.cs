    			var viewModel = new TemplateSampleViewModel(new[]
			                                            	{
			                                            		new TextTemplate {Name = "First", TemplateText = "This is the first item"},
			                                            		new TextTemplate {Name = "Second", TemplateText = "This is the second item"},
			                                            		new TextTemplate {Name = "Third", TemplateText = "This is the third item"},
			                                            	});
			var test = new UITemplateSample {DataContext = viewModel};
			test.Show();
