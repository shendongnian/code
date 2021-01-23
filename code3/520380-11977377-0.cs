    using System.Runtime.Serialization;
    var exception = FormatterServices.GetUninitializedObject(typeof(SqlException)) 
                    as SqlException;
    mockAccountDAL.Setup(m => m.CreateAccount(It.IsAny<string>(), "Display Name 2", 
                         It.IsAny<string>())).Throws(exception);
