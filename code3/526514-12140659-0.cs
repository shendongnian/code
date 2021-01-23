    interface IResponseVisitor {
        void VisitTvResponse(TvResponse r);
        void VisitDataResponse(DataResponse r);
    }
    interface IResponse {
        void Accept(IResponseVisitor v);
    }
    class TvResponse : IResponse {
        public void Accept(IResponseVisitor v) {
            v.VisitTvResponse(this);
        }
    }
    class DataResponse : IResponse {
        public void Accept(IResponseVisitor v) {
            v.VisitDataResponse(this);
        }
    }
