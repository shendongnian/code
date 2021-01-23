    ICriterion conjunction = Restrictions.Conjunction();
    conjunction.Add(Restrictions.Contains(criteria.Filter),"BusinessPartner.Name");
    conjunction.Add(Restrictions.Contains(criteria.Filter),"Group.Name");
    conjunction.Add(Restrictions.Contains(criteria.Filter),"Document.Name");
     ICriteria query = ICriteria.CreateCriteria
    .CreateAlias("BusinessPartner", "BusinessPartner", JoinType.LeftOuterJoin)
    .CreateAlias("Group", "Group", JoinType.LeftOuterJoin)
    .CreateAlias("Document", "Document", JoinType.LeftOuterJoin)
    .Add(Restrictions.Between(criteria.DateFrom,criteria.DateTo),"Date")
    .Add(conjunction));
    List<BusinessObject> results = query.List<BusinessObject>();
