    public ResultInfo DoSqlAction(Func<bool> f, string task, string ctx) {
        try {
            if (f.Invoke()) {
                return new ResultInfo(seq, task, "Success", ctx, true);
            } else {
                return new ResultInfo(seq, task, "Fail", ctx, false);
            }
        } catch (Exception ex) {
            return new ResultInfo(seq, task, "Error: " + ex.Message, ctx, false);
        }
    }
