	Expression<Func<Product, ProductInCityDto>> MyMappingExpression
	{
		get
		{
			return product => new ProductInCityDto
			{
				...
			}
		}
	}
