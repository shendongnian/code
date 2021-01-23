       //This is an application service method    
        public void AcceptTrade(Guid tradeId, Guid acceptingTraderId)
        {
            using (IUnitOfWork unitOfWork = UnitOfWorkFactory.Create())
            {
                Trade trade = _tradeRepository.GetById(tradeId);
                Trader acceptingTrader = _traderRepository.GetById(acceptingTraderId);
    
                trade.Accept(acceptingTrader);
    
                _tradeRepository.Save(trade);
            }
        }
