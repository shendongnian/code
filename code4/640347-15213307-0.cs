    public class YourSingleModelClassNameConfiguration : EntityTypeConfiguration<YourSingleModelClassName> {
    	public YourSingleModelClassNameConfiguration() {
    	
    		ToTable("Bill"); Property(param => param.Id).IsRequired().HasColumnName("BillId");
    	
    		// NOW REPEAT THAT FOR ALL BILL PROPERTIES WITH YOUR REQUIRED ATTRIBUTES (ISREQUIRED OR NOT, LENGTH ...)
    	
    		// NOW THE PROPERTIES YOU NEED TO MAP TO THE BILL ITEMS TABLE GOES INTO THE MAP FUNCTION
    		Map(
    		param =>
    			{ param.Properties(d => new {d.ItemId, d.User1}); m.ToTable("BillItem");
    			}
    		);
    	
    		// DON'T FORGET TO MENTION THE REST OF THE PROPERTIES BELONGING TO THE BillItem TABLE INSIDE THE PROPERTIES METHOD IN THE LAST LINE.
    	
    	}
    }
