        public void UpdateRiskInsight(RiskInsight item)
        {
            if (item == null)
            {
                throw new ArgumentException("Cannot add a null entity.");
            }
            if (item.RiskInsightID == Guid.Empty)
            {
                _db.RiskInsights.AddObject(item);
            }
            else
            {
                item.EntityKey = new System.Data.EntityKey("GRC9Entities.RiskInsights", "RiskInsightID", item.RiskInsightID);
                var entry = _db.GetObjectByKey(item.EntityKey) as RiskInsight;
                if (entry != null)
                {
                    _db.ApplyCurrentValues<RiskInsight>("GRC9Entities.RiskInsights", item);
                }
			}
            _db.SaveChanges();
        }
