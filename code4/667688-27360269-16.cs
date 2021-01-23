    public class AjaxTable<T> : IAjaxTable where T : new()
    {
        public List<AjaxTableColumn<T>> Columns { get; set; }
        public T Row { get; set; }
        public String AjaxUrl { get; set; }
        public RouteValueDictionary Attrs { get; set; }
        public IQueryable<T> Items { get; set; }
        
        public AjaxTable()
        {
            Columns = new List<AjaxTableColumn<T>>();
            Row = new T();
        }
        public HelperResult GetTh(int column)
        {
            return Columns[column].Th.Invoke(Row);
        }
        public string GetAjaxUrl()
        {
            return AjaxUrl;
        }
        public RouteValueDictionary GetAttrs()
        {
            return Attrs;
        }
        public int GetColumnsCount()
        {
            return Columns.Count;
        }
        public object DefaultAjaxAction()
        {
            var total = Items.Count();
            IQueryable<T> data = Search(Items, ParamSearchValue, ParamSearchRegex);
            var filtered = data.Count();
            data = Columns[ParamOrderColumn].OrderData(data, ParamOrderDirAscending);
            data = data.Skip(ParamStart).Take(ParamLength);
            return CreateAjaxResponse(data, total, filtered);
        }
        public IQueryable<T> Search(IQueryable<T> data, string search, bool regex)
        {
            if (search == null || search == "") return data;
            Expression orExpression = null;
            IReadOnlyCollection<ParameterExpression> parameters = null;
            foreach (var col in Columns)
            {
                if (col.KeyType == typeof(string))
                {
                    Expression<Func<T, string>> keySelector = (Expression<Func<T, string>>) col.KeySelector;
                    Expression compare = Expression.Call(keySelector.Body, typeof(String).GetMethod("Contains"), Expression.Constant(search));
                    if (orExpression == null)
                    {
                        orExpression = compare;
                        parameters = keySelector.Parameters;
                    }
                    else
                    {
                        orExpression = Expression.OrElse(compare, orExpression);
                    }
                }
            }
            if (orExpression != null)
            {
                Expression<Func<T, bool>> whereExpr = Expression.Lambda<Func<T, bool>>(orExpression, parameters);
                UnifyParametersVisitor visitor = new UnifyParametersVisitor();
                whereExpr = visitor.UnifyParameters(whereExpr);
                data = data.Where(whereExpr);
            }
            return data;
        }
        public object CreateAjaxResponse(IQueryable<T> data, int recordsTotal, int recordsFiltered)
        {
            Dictionary<string,object> obj = new Dictionary<string,object>();
            obj.Add("draw", HttpContext.Current.Request.Params["draw"]);
            obj.Add("recordsTotal", recordsTotal);
            obj.Add("recordsFiltered", recordsFiltered);
            List<T> dataList = data.ToList();
            String[][] cell = new String[dataList.Count()][];
            int rowIndex = 0;
            foreach (T row in dataList)
            {
                cell[rowIndex] = new String[Columns.Count];
                int colIndex = 0;
                foreach (var column in Columns)
                {
                    StringWriter sw = new StringWriter();
                    column.Td.Invoke(row).WriteTo(sw);
                    cell[rowIndex][colIndex++] = sw.ToString();
                    sw.Dispose();
                }
                rowIndex++;
            }
            obj.Add("data", cell);
            return obj;
        }
        public int ParamStart { get { return Int32.Parse(HttpContext.Current.Request.Params["start"]); } }
        public int ParamLength { get { return Int32.Parse(HttpContext.Current.Request.Params["length"]); } }
        public int ParamOrderColumn { get { return Int32.Parse(HttpContext.Current.Request.Params["order[0][column]"]); } }
        public bool ParamOrderDirAscending { get { return HttpContext.Current.Request.Params["order[0][dir]"] == "asc"; } }
        public string ParamSearchValue { get { return HttpContext.Current.Request.Params["search[value]"]; } }
        public bool ParamSearchRegex { get { return HttpContext.Current.Request.Params["search[regex]"] == "true"; } }
    }
