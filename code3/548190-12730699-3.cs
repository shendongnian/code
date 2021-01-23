	static MyClass<IT>()
	{
		if(!typeof(IT).IsInterface)
		{
			throw new WhateverException("Oi, only use interfaces.");
		}
	}
