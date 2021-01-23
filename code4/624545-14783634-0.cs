    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    [Xml.Serialization.XmlType("users", IncludeInSchema = true)]
    public class Users
    {
	[XmlElement("user")]
	public List<User> UserList {
		get {
			if (m_UserList == null) {
				m_UserList = new List<User>();
			}
			return m_UserList;
		}
	}
	private List<User> m_UserList;
    }
    [Xml.Serialization.XmlType("user", IncludeInSchema = true)]
    public class User
    {
	[XmlElement("name")]
	public string Name {
		get { return m_Name; }
		set { m_Name = value; }
	}
	private string m_Name;
	[XmlArray("orders")]
	public List<Orders> OrderList {
		get {
			if (m_OrderList == null) {
				m_OrderList = new List<Orders>();
			}
			return m_OrderList;
		}
	}
	private List<Orders> m_OrderList;
    }
    [Xml.Serialization.XmlType("orders", IncludeInSchema = true)]
    public class Orders
    {
	[XmlElement("number")]
	public string Number {
		get { return m_Number; }
		set { m_Number = value; }
	}
	private string m_Number;
    } 
