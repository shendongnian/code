	Expression<Func<ProductInCityDto, Product>> MyMappingExpression
	{
		get
		{
			return product => new ProductInCityDto
			{
				...
			}
		}
	}
