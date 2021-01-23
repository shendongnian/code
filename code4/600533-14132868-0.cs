    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Windows.Forms;
    namespace ExpressionSample
    {
        public class TestEntity
        {
            public int ID { get; set; }
            public string Text { get; set; }
            public decimal Money { get; set; }
        }
        public partial class GridForm : Form
        {
            public GridForm()
            {
                this.InitializeComponent();
            }
            private void GridForm_Load(object sender, EventArgs e)
            {
                this.FillGrid();
                this.FormatGrid();
            }
            private void FillGrid()
            {
                this.DataGridView.DataSource = TestDataProducer.GetTestData();
            }
            private void FormatGrid()
            {
                var redCellStyle = new DataGridViewCellStyle() { ForeColor = Color.Red };
                var moneyCellStyle = new DataGridViewCellStyle() { Format = "$###,###,##0.00" };
                this.GridColumn(e => e.ID).Visible = false;
                this.GridColumn(e => e.Text).DefaultCellStyle = redCellStyle;
                this.GridColumn(e => e.Money).DefaultCellStyle = moneyCellStyle;
            }
            private DataGridViewColumn GridColumn<TProperty>(Expression<Func<TestEntity, TProperty>> expr)
            {
                var propInfo = PropertyHelper<TestEntity>.GetProperty(expr);
                var column = this.DataGridView.Columns[propInfo.Name];
                return column;
            }
        }
        public static class PropertyHelper<T>
        {
            public static PropertyInfo GetProperty<TValue>(
                Expression<Func<T, TValue>> selector)
            {
                Expression body = selector;
                if (body is LambdaExpression)
                {
                    body = ((LambdaExpression)body).Body;
                }
                switch (body.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        return (PropertyInfo)((MemberExpression)body).Member;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
        public static class TestDataProducer
        {
            public static IList<TestEntity> GetTestData()
            {
                var entities = new List<TestEntity>();
                for (var i = 1; i <= 10; i++)
                {
                    var testEntity = new TestEntity {
                        ID = i,
                        Text = "Entity " + i.ToString(),
                        Money = i * 100m
                    };
                    entities.Add(testEntity);
                }
                return entities;
            }
        }
    }
