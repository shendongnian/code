     public void ApplyFilter(SortCriterionContext context)
        {
            bool ascending = false;
            if (context.State.SortAsc != null)
            {
                var _SortAsc = _tokenizer.Replace(
                    context.State.SortAsc, null, new ReplaceOptions { Encoding = ReplaceOptions.NoEncode });
                if (!string.IsNullOrWhiteSpace(_SortAsc)) ascending = Convert.ToBoolean(_SortAsc);
            }
            System.Collections.IDictionary dictionary = new Dictionary<string, string>();
            if (context.State.SortBy != null)
            {
                var _SortBy = _tokenizer.Replace(
                    context.State.SortBy, null, new ReplaceOptions { Encoding = ReplaceOptions.NoEncode });
                if (!string.IsNullOrWhiteSpace(_SortBy))
                {
                    switch ((string)_SortBy)
                    {
                        case "HR": //Highest Rated
                            dictionary.Add("Dimension", Dimensions.Rating.ToString());
                            dictionary.Add("FunctionName", "average");
                            break;
                        case "MF": //Most favorited
                            dictionary.Add("Dimension", Dimensions.Favorite.ToString());
                            dictionary.Add("FunctionName", "sum");
                            break;
                        case "MV":
                            //"Most viewed"
                            dictionary.Add("Dimension", Dimensions.ContentViews.ToString());
                            dictionary.Add("FunctionName", "sum");
                            break;
                            //ToDo: Need to work on recently published
                        default:
                            break;
                    }
                }
            }
            if (dictionary.Keys.Count == 0)
            {
                //This is to handle default case. //ToDo: Need to work on recently published
                dictionary.Add("Dimension", Dimensions.Rating.ToString());
                dictionary.Add("FunctionName", "average");
            }
            {
                var query = (IHqlQuery)context.Query;
                query.Join(alias => alias.ContentItem());
                var defaultHqlQuery = query as DefaultHqlQuery;
                var fiJoins = typeof(DefaultHqlQuery).GetField("_joins", BindingFlags.Instance | BindingFlags.NonPublic);
                var joins = fiJoins.GetValue(defaultHqlQuery) as List<System.Tuple<IAlias, Join>>;
                joins.Add(
                    new System.Tuple<IAlias, Join>(
                        new Alias("Contrib.Voting.Models"), new Join("ResultRecord", "result", ",")));
                context.Query = query.Where(
                    alias => alias.Named("result"), predicate => predicate.EqProperty("ContentItemRecord", "ci"));
                context.Query = context.Query.Where(
                    alias => alias.Named("result"), predicate => predicate.AllEq(dictionary));
                Action<IHqlSortFactory> sortOrderAction = x => x.Desc("Value");
                if (ascending) sortOrderAction = x => x.Asc("Value");
                context.Query = context.Query.OrderBy(alias => alias.Named("result"), sortOrderAction);
            }
        }
