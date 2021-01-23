    using System;
    using System.Data;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
    using Microsoft.SqlServer.Dts.Runtime.Wrapper;
    
    [Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
    public class ScriptMain : UserComponent
    {
        /// <summary>
        /// Our LINQ-able thing.
        /// </summary>
        List<Data> data;
    
        /// <summary>
        /// Do our preexecute tasks, in particular, we will instantiate
        /// our collection.
        /// </summary>
        public override void PreExecute()
        {
            base.PreExecute();
            this.data = new List<Data>();
        }
    
        /// <summary>
        /// This method is called once the last row has hit.
        /// Since we will can only find the highest OneToManyDataId
        /// after receiving all the rows, this the only time we can
        /// send rows to the output buffer.
        /// </summary>
        public override void FinishOutputs()
        {
            base.FinishOutputs();
            CreateNewOutputRows();
        }
    
        /// <summary>
        /// Accumulate all the input rows into an internal LINQ-able
        /// collection
        /// </summary>
        /// <param name="Row">The buffer holding the current row</param>
        public override void Input0_ProcessInputRow(Input0Buffer Row)
        {
            // there is probably a more graceful mechanism of spinning
            // up this struct.
            // You must also worry about fields that have null types.
            Data d = new Data();
            d.ID = Row.ID;
            d.Title = Row.Title;
            d.OneToManyId = Row.OneToManyDataID;            
            this.data.Add(d);
        }
    
        /// <summary>
        /// This is the process to generate new rows. As we only want to
        /// generate rows once all the rows have arrived, only call this
        /// at the point our internal collection has accumulated all the
        /// input rows.
        /// </summary>
        public override void CreateNewOutputRows()
        {
            foreach (var item in this.data.GroupBy(d => d.ID).Select(d => new { Item = d.Key }))
            {
                //Then pick out the highest OneToMany ID for that row to use with it.
                // Magic happens
                // I don't "get" LINQ so I can't implement the poster's action
                int id = 0;
                int maxOneToManyID = 2;
                string title = string.Empty;
                id = item.Item;
                Output0Buffer.AddRow();
                Output0Buffer.ID = id;
                Output0Buffer.OneToManyDataID = maxOneToManyID;
                Output0Buffer.Title = title;
            }
        }
    
    }
    /// <summary>
    /// I think this works well enough to demo
    /// </summary>
    public struct Data
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int OneToManyId { get; set; }
    }
