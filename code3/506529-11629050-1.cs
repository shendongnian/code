    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    
    namespace stock
    {
        class UnpackMarketPricesCompressed : stock.BFExchangeService.MarketPrices
    {
    		//The substitute code for "\:"
    	private const string ColonCode = "&%^@";
    
    	//Unpack the string
    	public UnpackMarketPricesCompressed(string MarketPrices)
    	{
    		string[] Mprices = null;
    		string[] Part = null;
    		string[] Field = null;
    		int n = 0;
    
    		Mprices = MarketPrices.Replace("\\:", ColonCode).Split(':');
    		//Split header and runner data
    		Field = Mprices[0].Replace("\\~", "-").Split('~');
    		//Split market data fields
    		marketId = Convert.ToInt32(Field[0]);
    		//Assign the market data
    		currencyCode = Field[1];
            marketStatus = (stock.BFExchangeService.MarketStatusEnum)Enum.Parse(typeof(stock.BFExchangeService.MarketStatusEnum), Field[2], true);
    		delay = Convert.ToInt32(Field[3]);
            numberOfWinners = Convert.ToInt32(Field[4]);
    		marketInfo = Field[5].Replace(ColonCode, ":");
    		discountAllowed = (Field[6].ToLower() == "true");
    		marketBaseRate = float.Parse(Field[7]);
    		lastRefresh = long.Parse(Field[8]);
    		removedRunners = Field[9].Replace(ColonCode, ":");
    		bspMarket = (Field[10] == "Y");
    
    		n = Mprices.Length - 1;
    		 // ERROR: Not supported in C#: ReDimStatement
    
    		//For each runner
    		for (int i = 0; i <= n; i++) 
            {
    			Part = Mprices[i + 1].Split('|');
    			//Split runner string into 3 parts
    			Field = Part[0].Split('~');
    			//Split runner data fields
    		     runnerPrices[i] = new stock.BFExchangeService.RunnerPrices();
    			var _with1 = runnerPrices[i];
    			//Assign the runner data
                _with1.selectionId = Convert.ToInt32(Field[0]);
                _with1.sortOrder = Convert.ToInt32(Field[1]);
                _with1.totalAmountMatched = Convert.ToDouble(Field[2]);
                _with1.lastPriceMatched = Convert.ToDouble(Field[3]);
                _with1.handicap = Convert.ToDouble(Field[4]);
                _with1.reductionFactor = Convert.ToDouble(Field[5]);
    			_with1.vacant = (Field[6].ToLower() == "true");
                _with1.farBSP = Convert.ToDouble(Field[7]);
                _with1.nearBSP = Convert.ToDouble(Field[8]);
                _with1.actualBSP = Convert.ToDouble(Field[9]);
    			_with1.bestPricesToBack = Prices(Part[1]);
    			_with1.bestPricesToLay = Prices(Part[2]);
    		}
    	}
    
    	private stock.BFExchangeService.Price[] Prices(string PriceString)
    	{
    		string[] Field = null;
    		stock.BFExchangeService.Price[] Price = null;
    		int k = 0;
    		int m = 0;
    
    		Field = PriceString.Split('~');
    		//Split price fields
    		m = (Field.Length / 4) - 1;
    		//m = number of prices - 1 
    		 // ERROR: Not supported in C#: ReDimStatement
    
    		for (int i = 0; i <= m; i++) 
            {
    			Price[i] = new stock.BFExchangeService.Price();
    			var _with2 = Price[i];
    			_with2.price = Convert.ToInt32(Field[k + 0]);
    			//Assign price data
    			_with2.amountAvailable = Convert.ToInt32(Field[k + 1]);
                _with2.betType = (stock.BFExchangeService.BetTypeEnum)Enum.Parse(typeof(stock.BFExchangeService.BetTypeEnum), Field[k + 2], true);
    			_with2.depth = Convert.ToInt32(Field[k + 3]);
    			k += 4;
    		}
    		return Price;
    		//Return the array of prices
    	}
    
        }
    }
