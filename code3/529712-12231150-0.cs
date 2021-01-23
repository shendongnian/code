    public class MyScoreQuery : Lucene.Net.Search.Function.CustomScoreQuery
    {
        public MyScoreQuery (Query q) : base(q)
        {
        }
        public override float CustomScore(int doc, float subQueryScore, float valSrcScore)
        {
            //read the doc if you need "indexReader.Document(doc)"
            //and apply your custom logic returning a float
        }
    } 
