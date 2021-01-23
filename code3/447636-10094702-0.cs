    [TableName("Product")]
    [PrimaryKey("ProductID")]
    [ExplicitColumns]
    public class Product {
		[PetaPoco.Column("ProductID")]
		public int ProductID { get; set; }
		[PetaPoco.Column("Name")]
		[Display(Name = "Name")]
        [Required]
		[StringLength(50)]
		public String Name { get; set; }
                ...
                ...
		[PetaPoco.Column("ProductTypeID")]
		[Display(Name = "ProductType")]
		public int ProductTypeID { get; set; }
		[ResultColumn]
		public string ProductType { get; set; }
                ...
                ...
        
		public static Product SingleOrDefault(int id) {
		    var sql = BaseQuery();
		    sql.Append("WHERE Product.ProductID = @0", id);
		    return DbHelper.CurrentDb().SingleOrDefault<Product>(sql);
		}
		public static PetaPoco.Sql BaseQuery(int TopN = 0) {
		    var sql = PetaPoco.Sql.Builder;
		    sql.AppendSelectTop(TopN);
		    sql.Append("Product.*, ProductType.Name as ProductType");
		    sql.Append("FROM Product");
		    sql.Append("    INNER JOIN ProductType ON Product.ProductoTypeID = ProductType.ProductTypeID");
		    return sql;
		}
