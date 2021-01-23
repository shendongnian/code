    DateTime datevalue;
    if (DateTime.TryParse(dr["DateFacturation"].ToString(), out datevalue))
    {
        emp.DateFacturation = datevalue;              
    }
    else
    {
        // TODO: conversion failed... not a valid DateTime
        // Print it out and see what is wrong with it...
    }
