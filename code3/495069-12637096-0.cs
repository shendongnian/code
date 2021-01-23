    class Tag { 
      int Id {get; set;}
      string Name {get; set;}
      IEnumerable<Tag> ChildTags  {get; set;}
    }
    
    public void Test()
    {
    var source =  new List<Tag>
    			{
    			    new Tag { Id = 1, Name = "Tag 1", ChildTags = new List<Tag>
    			                {
    			                    new Tag { Id = 2, Name = "Tag 2", ChildTags = new List<Tag> 
    											{
    			                    				new Tag {Id = 3, Name = "Tag 3"},
    			                    				new Tag {Id = 4, Name = "Tag 4"}
    			                    			}
    			                    	}
    			                }
    			        },
    			    new Tag { Id = 1, Name = "Tag 1" },
    			    new Tag {
    			            Id = 3, Name = "Tag 3", ChildTags = new List<Tag>
    			                {
    			                    new Tag {Id = 4, Name = "Tag 4"}
    			                }
    			        }
    			};
    
    Mapper.CreateMap<Tag, Tag>()
		.ForMember(dest => dest.ChildTags,
			opt => opt.MapFrom(src => src.ChildTags));
    var result = Mapper.Map<IList<Tag>, IList<Tag>>(tags);
    }
