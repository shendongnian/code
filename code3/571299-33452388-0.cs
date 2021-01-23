    private DataTable Excel_To_DataTable(string pRutaArchivo, int pHojaIndex)
		{
			// --------------------------------- //
			/* REFERENCIAS:
			 * NPOI.dll
			 * NPOI.OOXML.dll
			 * NPOI.OpenXml4Net.dll */
			// --------------------------------- //
			/* USING:
			 * using NPOI.SS.UserModel;
			 * using NPOI.HSSF.UserModel;
			 * using NPOI.XSSF.UserModel; */
			// --------------------------------- //
			DataTable Tabla = null;
			try
			{
				if (System.IO.File.Exists(pRutaArchivo))
				{
					IWorkbook workbook = null;	//IWorkbook determina se es xls o xlsx	 			
					ISheet worksheet = null;
					string first_sheet_name = "";
					using (FileStream FS = new FileStream(pRutaArchivo, FileMode.Open, FileAccess.Read))
					{
						workbook = WorkbookFactory.Create(FS); //Abre tanto XLS como XLSX
						worksheet = workbook.GetSheetAt(pHojaIndex); //Obtener Hoja por indice
						first_sheet_name = worksheet.SheetName;  //Obtener el nombre de la Hoja
						Tabla = new DataTable(first_sheet_name);
						Tabla.Rows.Clear();
						Tabla.Columns.Clear();
						// Leer Fila por fila desde la primera
						for (int rowIndex = 0; rowIndex <= worksheet.LastRowNum; rowIndex++)
						{
							DataRow NewReg = null;
							IRow row = worksheet.GetRow(rowIndex);
							IRow row2 = null;
							if (row != null) //null is when the row only contains empty cells 
							{
								if (rowIndex > 0) NewReg = Tabla.NewRow();
								//Leer cada Columna de la fila
								foreach (ICell cell in row.Cells)
								{
									object valorCell = null;
									string cellType = "";
									if (rowIndex == 0) //Asumo que la primera fila contiene los titlos:
									{
										row2 = worksheet.GetRow(rowIndex + 1); //Si es la rimera fila, obtengo tambien la segunda para saber los tipos:
										ICell cell2 = row2.GetCell(cell.ColumnIndex);
										switch (cell2.CellType)
										{
											case CellType.Boolean: cellType = "System.Boolean"; break;
											case CellType.String: cellType = "System.String"; break;
											case CellType.Numeric:
												if (HSSFDateUtil.IsCellDateFormatted(cell2)) { cellType = "System.DateTime"; }
												else { cellType = "System.Double"; }		break;
											case CellType.Formula:
												switch (cell2.CachedFormulaResultType)
												{
													case CellType.Boolean: cellType = "System.Boolean"; break;
													case CellType.String: cellType = "System.String"; break;
													case CellType.Numeric:
														if (HSSFDateUtil.IsCellDateFormatted(cell2)) { cellType = "System.DateTime"; }
														else { cellType = "System.Double"; }	break;
												}
												break;
											default:
												cellType = "System.String"; break;
										}
										//Agregar los campos de la tabla:
										DataColumn codigo = new DataColumn(cell.StringCellValue, System.Type.GetType(cellType));
										Tabla.Columns.Add(codigo);
									}
									else
									{
										//Las demas filas son registros:
										switch (cell.CellType)
										{
											case CellType.Blank:	valorCell = DBNull.Value; break;
											case CellType.Boolean:	valorCell = cell.BooleanCellValue; break;
											case CellType.String:	valorCell = cell.StringCellValue; break;
											case CellType.Numeric:
												if (HSSFDateUtil.IsCellDateFormatted(cell)) { valorCell = cell.DateCellValue; }
												else { valorCell = cell.NumericCellValue; } break;
											case CellType.Formula:
												switch (cell.CachedFormulaResultType)
												{
													case CellType.Blank:	valorCell = DBNull.Value; break;
													case CellType.String:	valorCell = cell.StringCellValue; break;
													case CellType.Boolean:	valorCell = cell.BooleanCellValue; break;
													case CellType.Numeric:
														if (HSSFDateUtil.IsCellDateFormatted(cell)) { valorCell = cell.DateCellValue; }
														else { valorCell = cell.NumericCellValue; }
														break;
												}
												break;											
											default: valorCell = cell.StringCellValue; break;
										}
										NewReg[cell.ColumnIndex] = valorCell;
									}
								}
							}
							if (rowIndex > 0) Tabla.Rows.Add(NewReg);
						}
						Tabla.AcceptChanges();
					}
				}
				else
				{
					throw new Exception("ERROR 404: El archivo especificado NO existe.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Tabla;
		}
