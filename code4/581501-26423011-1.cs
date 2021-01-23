    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    
    public class SqlBuilder
    {
    private StringBuilder _rq;
    private SqlCommand _cmd;
    private int _seq;
    public SqlBuilder(SqlCommand cmd)
    {
        _rq = new StringBuilder();
        _cmd = cmd;
        _seq = 0;
    }
    public SqlBuilder Append(String str)
    {
        _rq.Append(str);
        return this;
    }
    public SqlBuilder Value(Object value)
    {
        string paramName = "@SqlBuilderParam" + _seq++;
        _rq.Append(paramName);
        _cmd.Parameters.AddWithValue(paramName, value);
        return this;
    }
    public SqlBuilder FuzzyValue(Object value)
    {
        string paramName = "@SqlBuilderParam" + _seq++;
        _rq.Append("'%' + " + paramName + " + '%'");
        _cmd.Parameters.AddWithValue(paramName, value);
        return this;
    }
    public override string ToString()
    {
        return _rq.ToString();
    }
    }
    
